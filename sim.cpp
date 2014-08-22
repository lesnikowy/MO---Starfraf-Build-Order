#include "sim.h"

sim::sim() {
	time = 0;
	resources = 0;
	unit_list.erase();
}

sim::~sim() {
	// nothing to destroy ;(
}

unsigned int sim::run(vectror<unit_type> raw_unit_vector) {

	build_unit_list(raw_unit_vector);

	// do the other stuff

}

void sim::build_unit_list(vector<unit_type> raw_unit_vector) {
	unit_list.erase();
	
	// start with 4 SCV and one CMD_CENTER
	unit_list.push_back(CMD_CENTER, true);
	for (int i = 0; i < 4; i ++) {
		unit_list.push_back(SCV, true);
	}

	// translate IDs for simulation structures
	for (int i = 0; i < raw_unit_vector.size(); i ++) {
		unit_list.push_back(raw_unit_vector[i]);
	}
}
