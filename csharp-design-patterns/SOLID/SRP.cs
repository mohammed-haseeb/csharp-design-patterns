namespace csharp_design_patterns.SOLID.SRP
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count;

        public int AddEntry(string text)
        {
            entries.Add(text);
            count++;
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, entries);
        }

        // breaks SRP
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }
        public void Load(Uri uri)
        {

        }

    }

    // handles reponsibility of persisting objects
    public class PersistenceManager
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, journal.ToString());
            }
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Hello World");
            j.AddEntry("Hello C#");
            Console.WriteLine(j);


            var p = new PersistenceManager();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
        }
    }


}
