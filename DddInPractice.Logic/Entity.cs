using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddInPractice.Logic
{
	public abstract class Entity
	{
		public long Id { get; private set; }

		public override bool Equals(object obj)
		{
			var other = obj as Entity;

			if (ReferenceEquals(other, null))
				return false;

			if (ReferenceEquals(this, other))
				return true;

			if (this.GetType() != other.GetType())
				return false;

			if (this.Id == 0 || other.Id == 0)
				return false;

			return this.Id == other.Id;
		}

		public override int GetHashCode()
		{
			return (this.GetType().ToString() + this.Id).GetHashCode();
		}

		public static bool operator ==(Entity a, Entity b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
				return true;
			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
				return false;

			return a.Equals(b);
		}

		public static bool operator !=(Entity a, Entity b)
		{
			return !(a == b);
		}
	}
}
