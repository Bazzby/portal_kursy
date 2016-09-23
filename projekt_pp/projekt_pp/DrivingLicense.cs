using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
	class DrivingLicense
	{
		private bool B { get; set; }
		private bool C1 { get; set; }
		private bool C { get; set; }
		private bool D1 { get; set; }
		private bool D { get; set; }
		private bool BE { get; set; }
		private bool C1E { get; set; }
		private bool CE { get; set; }
		private bool D1E { get; set; }
		private bool DE { get; set; }

		DrivingLicense(bool B = false, bool C1 = false, bool C = false, bool D1 = false, bool D = false, bool BE = false, bool C1E = false, bool CE = false,
			bool D1E = false, bool DE = false)
		{
			this.B = B;
			this.C1 = C1;
			this.C = C;
			this.D1 = D1;
			this.D = D;
			this.BE = BE;
			this.C1E = C1E;
			this.CE = CE;
			this.D1E = D1E;
			this.DE = DE;
		}
	}
}