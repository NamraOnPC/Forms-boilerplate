using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROQuestion1FinalExam
{

    class EmployeeException : Exception
    {
        private int ErrCode { get; set; }

        private String ErrMsg { get; set; }

        public int getErrorCode()
        {
            return ErrCode;
        }

        public String getErrorMessage()
        {
            return ErrMsg;
        }

        public EmployeeException(int errorCode, String message)
        : base(String.Format("Employee Exception"))
        {
            ErrCode = errorCode;
            ErrMsg = message;

            var code = getErrorCode();
            var msg = getErrorMessage();

            Console.WriteLine($"Error Code: {code}    Error Message: {message}");
        }

    }



    public abstract class Employee
    {
        public String Name { get; }

        public String JobType;

        public double Income { get;}


        public Employee(String name, double income)
        {
            if (name == null)
            {
                throw new EmployeeException(10 , "Name not found!");
            }
            else if(income < 0)
            {
                throw new EmployeeException(20, "Invalid Income!");
            }else
            {
                Name = name;
                Income = income;
            }
        }

        public abstract String getDocumentAccess();

    }

    public class CEO : Employee
    {
        public CEO(String name, double income) : base(name, income)
        {
            JobType = "CEO";
        }

        public String getJobType()
        {
            return JobType;
        }


        public override String getDocumentAccess()
        {
           return String.Format($"Work Place, Classified Documents, Financial Documents");
        }
    }


    public class Accountant : Employee
    {
        public Accountant(String name,double income) : base(name, income)
        {
            JobType = "Accountant";
        }

        public String getJobType()
        {
            return JobType;
        }

        public override string getDocumentAccess()
        {
            return String.Format($"Work Place, Financial Documents");
        }
    }


    public class Clerk : Employee
    {

        public Clerk(String name, double income) : base(name, income)
        {
            JobType = "Clerk";
        }

        public String getJobType()
        {
            return JobType;
        }

        public override string getDocumentAccess()
        {
            return String.Format($"Work Place");
        }
    }


    public class ApplicationTester
    {

        public static void Main(string[] args)
        {
            CEO ceo = new CEO("Ozzy Osbourne", 125000);
            Accountant accountant = new Accountant("Kevin Durant", 25000);
            Clerk clerk = new Clerk("Kevin Spacey", 5000);

            Console.WriteLine($"Name: {ceo.Name}; Type: {ceo.getJobType()}; Income: {ceo.Income}; Access to: {ceo.getDocumentAccess()}");
            Console.WriteLine($"Name: {accountant.Name}; Type: {accountant.getJobType()}; Income: {accountant.Income}; Access to: {accountant.getDocumentAccess()}");
            Console.WriteLine($"Name: {clerk.Name}; Type: {clerk.getJobType()}; Income: {clerk.Income}; Access to: {clerk.getDocumentAccess()}");

            Console.ReadKey();
        }
    }

}
