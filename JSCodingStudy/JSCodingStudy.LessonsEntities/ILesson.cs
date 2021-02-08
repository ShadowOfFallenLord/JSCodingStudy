using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.LessonsEntities
{
    public interface ILesson
    {
        int Id { get; set; }
        string Title { get; set; }
    }
}
