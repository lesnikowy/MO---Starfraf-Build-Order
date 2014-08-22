#include <unit.h>
#include <sim.h>


int main () {
	bool finished;
	sim sim_unit;
	unsigned int score;
	// do not include starting units: SCVs and Command Center
	vector <unit_type> bld_order;

	init_unit_params();

	// initialize bld_order vector
	
	while ( ! finished ) {
		score = sim_unit.run(bld_order);

		// play with the bld_order and simulation scores
	}
}
