using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;

public class SimModel : PageModel
{
    private static SimulationLog? _log;

    public int Turn { get; private set; }
    public int MaxTurn { get; private set; }

    public int SizeX { get; private set; }
    public int SizeY { get; private set; }

    public string Mappable { get; private set; } = "";
    public string Move { get; private set; } = "";
    public string MoveArrow { get; private set; } = "";

    private Dictionary<Point, List<char>> _symbols = new();

    public void OnGet()
    {
        EnsureLog();

        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        Turn = Clamp(Turn, 0, MaxTurn);
        HttpContext.Session.SetInt32("Turn", Turn);

        RenderTurn();
    }

    public IActionResult OnPost(string action)
    {
        EnsureLog();

        var current = HttpContext.Session.GetInt32("Turn") ?? 0;

        if (action == "prev") current--;
        if (action == "next") current++;

        Turn = Clamp(current, 0, MaxTurn);
        HttpContext.Session.SetInt32("Turn", Turn);

        return RedirectToPage();
    }

    private void EnsureLog()
    {
        if (_log is null)
        {
            SmallTorusMap map = new(8, 6);

            var elf = new Elf("Elandor");
            var orc = new Orc("Gorbag");

            var rabbits = new Animals { Description = "Rabbits", Size = 5 };
            var eagles = new Birds { Description = "Eagles", CanFly = true };
            var ostriches = new Birds { Description = "Ostriches", CanFly = false };

            List<IMappable> objects = [elf, orc, rabbits, eagles, ostriches];

            List<Point> points =
            [
                new(1, 1),
                new(2, 2),
                new(3, 3),
                new(4, 4),
                new(5, 2)
            ];

            string moves = "urdlurdlurdlurdlurdl";

            var simulation = new Simulation(map, objects, points, moves);
            _log = new SimulationLog(simulation);
        }

        MaxTurn = _log.TurnLogs.Count - 1;
        SizeX = _log.SizeX;
        SizeY = _log.SizeY;
    }

    private void RenderTurn()
    {
        if (_log is null) return;

        Turn = Clamp(Turn, 0, MaxTurn);

        var turnLog = _log.TurnLogs[Turn];

        _symbols = turnLog.SymbolsList;

        if (Turn == 0)
        {
            Mappable = "";
            Move = "";
            MoveArrow = "";
        }
        else
        {
            Mappable = turnLog.Mappable;
            Move = turnLog.Move;
            MoveArrow = ToArrow(turnLog.Move);
        }
    }

    public IEnumerable<string> GetImages(int x, int y)
    {
        var p = new Point(x, y);
        if (!_symbols.TryGetValue(p, out var list) || list.Count == 0)
            return Enumerable.Empty<string>();

        return list.Select(SymbolToImg);
    }

    private static string SymbolToImg(char s)
    {
        return s switch
        {
            'E' => "/img/elf.png",
            'O' => "/img/orc.png",
            'A' => "/img/rabbit.png",

            'B' => "/img/bird.png",
            'b' => "/img/ostrich.png",

            _ => "/img/bird.png"
        };
    }

    private static string ToArrow(string move)
    {
        return move.ToLowerInvariant() switch
        {
            "up" => "→ up",
            "down" => "→ down",
            "left" => "→ left",
            "right" => "→ right",
            "u" => "→ up",
            "d" => "→ down",
            "l" => "→ left",
            "r" => "→ right",
            _ => $"→ {move}"
        };
    }

    private static int Clamp(int value, int min, int max)
        => value < min ? min : (value > max ? max : value);
}
