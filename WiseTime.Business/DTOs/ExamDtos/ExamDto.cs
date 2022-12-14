using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseTime.Business.DTOs.ExamDtos
{
    public class ExamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<ExamTypeDto> ExamTypes { get; set; }
    }
}
