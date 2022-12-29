using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Guid? ParentId { get; private set; }
        public Category Parent { get; private set; }
        public Guid UserCreationId { get; private set; }
        public User UserCreation { get; private set; }

        public Category() { }

    }
}
