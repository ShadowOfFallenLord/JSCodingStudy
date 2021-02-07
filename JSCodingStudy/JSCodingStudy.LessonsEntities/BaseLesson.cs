using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.LessonsEntities
{
    public class BaseLesson : ILesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
