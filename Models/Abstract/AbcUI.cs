using schoolApp.Types.Enums;
using Spectre.Console;

namespace schoolApp.Models.@Abstract;

public abstract class AbcUI
{

    public string GetData(Func<string, bool> validation,
    string message, string exceptionMessage)
    {
        while (true)
        {
            string data = AnsiConsole.Ask<string>(message);
            if (!validation(data))
            {
                AnsiConsole.Clear();
                AnsiConsole.Markup(exceptionMessage);
            }
            else
            {
                AnsiConsole.Clear();
                return data;
            }
        }
    }

    public Stats GetStats(string title)
    {
        while (true)
        {
            var statsResult = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title(title)
            .AddChoices("Ativo", "Desativado")
            );
            AnsiConsole.Clear();
            return statsResult == "Ativo" ?
            Stats.Enabled : Stats.Disabled;
        }
    }

    public Group GetGroup(string title)
    {
        while (true)
        {
            var groupResult = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(
            "1 - Turma A", "2 - Turma B",
            "3 - Turma C", "4 - Turma D",
            "5 - Turma E"
            ));

            Group group = groupResult switch
            {
                "1 - Turma A" => Group.A,
                "2 - Turma B" => Group.B,
                "3 - Turma C" => Group.C,
                "4 - Turma D" => Group.D,
                "5 - Turma E" => Group.E,
                _ => throw new NotImplementedException()
            };

            AnsiConsole.Clear();
            return group;
        }

    }

}
