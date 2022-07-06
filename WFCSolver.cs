using System.Text;

namespace WFC;

class WFCSolver
{
    public MapConfiguration Configuration { get; set; }
    Random _rng { get; } = new Random();
    
    public WFCSolver(MapConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void Solve()
    {
        for (int x = 0; x < Configuration.Width; x++)
        {
            for (int y = 0; y < Configuration.Height; y++)
            {
                if (!Configuration.IsAssigned(x, y))
                {
                    if (Configuration.Domain[x, y].Count > 0)
                    {
                        int value = GetRandomValueFromDomain(x, y);
                        Configuration.Assign(x, y, value);
                    }
                }
            }
        }
    }

    public int GetRandomValueFromDomain(int x, int y)
    {
        List<int> domain = Configuration.Domain[x, y];
        return domain[_rng.Next(domain.Count)];
    }

    public void Print()
    {
        StringBuilder sb = new StringBuilder();

        for(int y = 0; y < Configuration.Height; y++)
        {
            for (int x = 0; x < Configuration.Width; x++)
            {
                sb.Append(Configuration[x, y].ToString().PadLeft(2, ' '));
                sb.Append(" ");
            }

            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}