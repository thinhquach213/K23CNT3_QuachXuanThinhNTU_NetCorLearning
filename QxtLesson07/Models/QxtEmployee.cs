using System.ComponentModel.DataAnnotations;

namespace QxtLesson07.Models
{
    public class QxtEmployee
    {
        
        public int QxtID { get; set; }

        
        public string QxtName { get; set; }

       
        public DateTime QxtBirthDay { get; set; }

        
        public string QxtEmail { get; set; }

      
        public string QxtPhone { get; set; }

       
        public decimal QxtSalary { get; set; }

        public bool QxtStatus { get; set; }
    }

}
