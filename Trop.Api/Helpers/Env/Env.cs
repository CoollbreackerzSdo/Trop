namespace Trop.Api.Helpers.Env;

public static class Env
{
    public static void ReadEnvFile(string path)
    {
        if (File.Exists(path))
        {
            ReadOnlySpan<string> lines = File.ReadAllLines(path);
            foreach (ReadOnlySpan<char> line in lines)
            {
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == '=')
                    {
                        Environment.SetEnvironmentVariable(line[..i].ToString(), line[(i + 1)..].ToString());
                        break;
                    }
                }
            }
        }
    }
}