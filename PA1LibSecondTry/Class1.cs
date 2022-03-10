namespace PA1LibSecondTry
{
    public class Class1
    {
        public static List<string> markTypeList = new List<string>() { "Б", "П", "У" };
        public static Random rand = new Random();
        public class Student
        {
            public Student(DateTime _year, int _group, string _name)
            {
                AdmissionYear = _year;
                ClassGroup = _group;
                FullName = _name;
            }
            public DateTime AdmissionYear { get; set; }
            public int ClassGroup { get; set; }
            public string FullName { get; set; }
        }

        public class Mark
        {
            public DateTime Date { get; set; }
            public string _estimation;
            public Student StudentData { get; set; }
            public string Estimation
            {
                get
                {
                    return _estimation;
                }

                set
                {
                    if (markTypeList.Contains(value))
                    {
                        _estimation = value;
                    }
                    else
                    {
                        try
                        {
                            Convert.ToDouble(value);
                            _estimation = value;
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        #region Methods
        public static int[] CountByCategory(List<Mark> marks, string category)
        {
            List<int> Years = marks.Select(c => c.Date.Year).ToList();
            List<int> Month = marks.Select(c => c.Date.Month).ToList();
            Years = Years.Distinct().ToList();
            Month = Month.Distinct().ToList();
            List<int> result = new List<int>();

            foreach (int year in Years)
            {
                foreach (int month in Month)
                {
                    List<Mark> currentMonth = marks.Where(c => c.Date.Month == month && c.Date.Year == year).ToList();

                    int push = currentMonth.Where(c => c.Estimation == category).ToList().Count();
                    if (push > 0)
                        result.Add(push);
                }
            }

            return result.ToArray();
        }

        public static double MinAVG(string[] marks)
        {
            double resultAvg;
            List<double> marksList = new List<double>();

            foreach (string mark in marks)
            {
                try
                {
                    //Округление
                    Double value = Convert.ToDouble(mark);

                    marksList.Add(value);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            resultAvg = marksList.Average();
            return Math.Floor(resultAvg);
        }

        public static int[] GetCountTruancy(List<Mark> marks)
        {
            return CountByCategory(marks, "П");
        }

        public static int[] GetCountDisease(List<Mark> marks)
        {
            return CountByCategory(marks, "Б");
        }

        public static string GetStudNumber(int year, int group, string fio)
        {
            string[] initial = fio.Split(' ');
            return $"{year}.{group}.{initial[0][0]}{initial[1][0]}{initial[2][0]}";
        }

        public static List<Mark> GetMarks(DateTime now, List<Student> students)
        {
            List<Mark> result = new List<Mark>();

            for (int i = now.Day; i < now.Day + 10; i++)
            {
                DateTime current = new DateTime(now.Year, now.Month, i);

                foreach (Student student in students)
                {
                    string pushData = markTypeList[rand.Next(0, 3)];

                    result.Add(new Mark() { Date = current, StudentData = student, Estimation = pushData });
                }
            }

            return result;
        }
        #endregion
    }
}