internal class Program {

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите номер задания: 1-6 - задания первого дня, 7-14 - задания второго дня");
        List<Employee> employees = new()
        {
            new Employee("Шевченко Артём Денисович", 1, 56140.43),
            new Employee("Монтье Алексей Фёдорович", 2, 28335.43),
            new Employee("Дуга Марина Вольфовна", 2, 16455.43),
            new Employee("Элемберг Амалия Вадимовна", 3, 26553.43),
            new Employee("Элемберг Эрнстина Вадимовна", 3, 47862.43),
            new Employee("Климов Сергей Петрович", 1, 46446.43),
            new Employee("Шевченко Макар Николаевич", 4, 36568.43),
            new Employee("Смоляков Егор Андреевич", 5, 23655.43),
            new Employee("Бронин Владислав Владиславович", 4, 25735.43),
            new Employee("Погосян Артур Родионович", 5, 25855.43)
        };

        void EmployeeInfo() //1 - Получить список всех сотрудников со всеми данными
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"Cотрудник под номером {emp._id} - {emp.Fio}, работающий в отделе " +
                    $"{emp.Department} получает зарплату в размере" +
                    $" {emp.Salary}");
            }
        }
        void SalarySum() //2 - Посчитать сумму затрат на зарплаты в месяц
        {
            double sum = 0;
            foreach(Employee emp in employees)
            {
                sum += emp.Salary;
            }
            Console.WriteLine($"Сумма затрат на зарплаты в месяц: {sum}");

        }
        void EmployeerMinSalary() //3 - Найти сотрудника с минимальной зарплатой
        {
                Console.WriteLine($"Человек с самой минимальной зарплатой {employees.Min(e => e.Salary + "рублей: " + e.Fio)} " );
        }
        void EmployeerMaxSalary() //4 - Найти сотрудника с максимальной зарплатой
        {
            Console.WriteLine($"Человек с самой максимальной зарплатой {employees.Max(e => e.Salary+ "рублей: " + e.Fio)} ");
        }
        void SalaryAverage() //5 - Подсчитать среднее значение зарплат
        {
            Console.WriteLine($"Среднее значение зарплат: {employees.Average(e => e.Salary)}");
        }
        void EmployeesFIO() //6 - Получить ФИО всех сотрудников
        {   foreach(var emp in employees)
            {
                Console.WriteLine($"ФИО сотрудника: {emp._id} {emp.Fio}");
            }
            
        }
        void SalaryIndex() //7 - Проиндексировать зарплату
        {
            Console.WriteLine("Введите процент на который увеличится зарплата работников: ");
            double percent = double.Parse(Console.ReadLine()); 
                                                              
            double salary;
            foreach ( var emp in employees)
            {
                salary = emp.Salary + (emp.Salary / percent);
        
                Console.WriteLine($"Теперь зарплата сотрудника {emp.Fio} составляет: {salary} рублей");
            }
         
        }
        void MinSalaryDeparment() //8 - Найти сотрудника с минимальной зарплатой в отделе
        {
           Console.WriteLine("Введите номер отдела: ");
           double dep_choice = Double.Parse(Console.ReadLine());
            
                var emp_in_dep = employees.Where(e => e.Department == dep_choice);
                if (emp_in_dep.Any())
                {
                    var minsalary = emp_in_dep.OrderBy(e => e.Salary).First();
                   
                    Console.WriteLine($"В отделе номер {dep_choice} минимальная зп равна {minsalary.Salary} у сотрудника {minsalary.Fio}");
                }
            
        }

        void MaxSalaryDepartment() //9 - Найти сотрудника с максимальной зарплатой в отделе
        {
            Console.WriteLine("Введите номер отдела: ");
            double dep_choice = Double.Parse(Console.ReadLine());

            var emp_in_dep = employees.Where(e => e.Department == dep_choice);
            if (emp_in_dep.Any())
            {
                var maxsalary = emp_in_dep.OrderBy(e => e.Salary).Last();

                Console.WriteLine($"В отделе номер {dep_choice} максимальная зп равна {maxsalary.Salary} у сотрудника {maxsalary.Fio}");
            }
        }
        void AverageSalaryDepartment() // 10 - Средняя зарплата по отделу
        {
            Console.WriteLine("Введите номер отдела: ");
            double dep_choice = Double.Parse(Console.ReadLine());

            var emp_in_dep = employees.Where(e => e.Department == dep_choice);
            if (emp_in_dep.Any())
            {
                var averagesalary = emp_in_dep.Average(e => e.Salary);

                Console.WriteLine($"В отделе номер {dep_choice} средняя зп равна {averagesalary}");
            }
        }
        void IndexSalaryDepartment() //11 - Проиндексировать зарплату сотрудников в отделе (не работает)
        {
            Console.WriteLine("Введите номер отдела: ");
            int dep_choice = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите процент, на который увеличится зарплата: ");
            int index = Int32.Parse(Console.ReadLine());
            var emp_in_dep = employees.Where(e => e.Department == dep_choice);
            if (emp_in_dep.Any())
            {
                var indexsalary = emp_in_dep.OrderBy(e => e.Salary);
 
                Console.WriteLine($"Теперь зарплата сотрудника в отделе {dep_choice} равна: {indexsalary}");
            }
                
            
        }
        void EmployeesDepartmentINFO() //12 - Все сотрудники отдела 
        {
            Console.WriteLine("Введите номер отдела: ");
            int dep_choice = Int32.Parse(Console.ReadLine());
            foreach (var emp in employees)
            {
                if (emp.Department == dep_choice)
                {
                    Console.WriteLine($"Cотрудник под номером {emp._id} - {emp.Fio} получает зарплату в размере {emp.Salary}");
                }
            }
        }
        void SalaryLessThanNumber() //13 - Все сотрудники отдела с зарплатой меньше числа
        {
            Console.WriteLine("Введите число:");
            double expected_salary = double.Parse(Console.ReadLine());
            
            foreach (var emp in employees)
            {  if(emp.Salary < expected_salary)
                Console.WriteLine($"Cотрудник под номером {emp._id} - {emp.Fio}, работающий в отделе " +
                    $"{emp.Department} получает зарплату в размере" +
                    $" {emp.Salary}");
            }
        }
        void SalaryMoreThanNumber() //14 - Все сотрудники с зарплатой больше числа
        {
            Console.WriteLine("Введите число:");
            double expected_salary = double.Parse(Console.ReadLine());

            foreach (var emp in employees)
            {
                if (emp.Salary >= expected_salary)
                    Console.WriteLine($"Cотрудник под номером {emp._id} - {emp.Fio}, работающий в отделе " +
                        $"{emp.Department} получает зарплату в размере" +
                        $" {emp.Salary}");
            }
        }

        int choice = Int32.Parse(Console.ReadLine());
        switch (choice)
        {  
            case 1:
                EmployeeInfo();
                break;
            case 2:
                SalarySum();
                break;
            case 3:
                EmployeerMinSalary();
                break;
            case 4:
                EmployeerMaxSalary();
                break;
            case 5:
                SalaryAverage();
                break;
            case 6:
               EmployeesFIO();
                break;
            case 7:
                SalaryIndex();
                break;
            case 8:
                MinSalaryDeparment();
                break;
            case 9:
                MaxSalaryDepartment();
                break;
            case 10:
                AverageSalaryDepartment();
                break;
            case 11:
                IndexSalaryDepartment();
                break;
            case 12:
                EmployeesDepartmentINFO();
                break;
            case 13:
                SalaryLessThanNumber();
                break;
            case 14:
                SalaryMoreThanNumber();
                break;
        }
    }
}