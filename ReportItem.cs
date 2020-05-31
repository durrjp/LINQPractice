namespace LINQPractice
{
    public class ReportItem
        {
            public string CustomerName { get; set; }
            public string BankName { get; set; }

            private string[] FirstAndLast 
            {
                get
                {
                    return CustomerName.Split(' ');
                }
            } 

            public string FirstName 
            {
                get
                {
                    return FirstAndLast[0];
                }
            }

            public string LastName 
            {
                get
                {
                    return FirstAndLast[1];
                }
            }

        }
}