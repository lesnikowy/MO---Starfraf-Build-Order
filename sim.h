#include "unit.h"

class sim {
	public:
		sim();
		~sim();

		unsigned int run(vector<unit_type>);

	private:
		void build_unit_list(vector<unit_type>);

		unsigned int time;
		unsigned int resources;

		list <unit> unit_list;
};
