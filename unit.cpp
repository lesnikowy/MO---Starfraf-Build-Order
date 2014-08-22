#include "unit.h"
#include <stdlib>

unit_param::unit_param(unit_type type) {
	switch (type) {
		NO_UNIT:
			//skip for compilance
			break;

		SCV:
			name.assign("SCV");
			cost = 50;
			bld_time = 20;
			size = 1;
			supply = 0;
			building = false;
			products.push_back(CMD_CENTER);
			products.push_back(SUPPLY_DEPOT); 
			products.push_back(BARRACKS};
			products.push_back(FACTORY);
			products.push_back(ARMORY);
			products.push_back(MACHINE_SHOP);
			requirements.push_back(CMD_CENTER);
			break;
		MARINE:
			name.assign("Marine");
			cost = 50;
			bld_time = 25;
			size = 1;
			supply = 0;
			building = false;
			products.erase();
			requirements.push_back(CMD_CENTER); 
			requirements.push_back(BARRACKS};
			break;
		FIREBAT:
			name.assign("Firebat");
			cost = 75;
			bld_time = 30;
			size = 1;
			supply = 0;
			building = false;
			products.erase();
			requirements.push_back(CMD_CENTER); 
			requirements.push_back(BARRACKS};
			requirements.push_back(ACADEMY);
			break;
		GHOST:
			name.assign("Ghost");
			cost = 100;
			bld_time = 50;
			size = 1;
			supply = 0;
			building = false;
			products.erase();
			requirements.push_back(CMD_CENTER); 
			requirements.push_back(BARRACKS};
			requirements.push_back(ACADEMY);
			break;
		VULTURE:
			name.assign("Vulture");
			cost = 70;
			bld_time = 35;
			size = 2;
			supply = 0;
			building = false;
			products.erase();
			requirements.push_back(CMD_CENTER); 
			requirements.push_back(BARRACKS};
			requirements.push_back(FACTORY);
			break;
		TANK:
			name.assign("Tank");
			cost = 150;
			bld_time = 50;
			size = 3;
			supply = 0;
			building = false;
			products.erase();
			requirements.push_back(CMD_CENTER); 
			requirements.push_back(BARRACKS};
			requirements.push_back(FACTORY);
			requirements.push_back(MACHINE_SHOP);
			break;
		GOLIATH:
			name.assign("Goliath");
			cost = 125;
			bld_time = 45;
			size = 2;
			supply = 0;
			building = false;
			products.erase();
			requirements.push_back(CMD_CENTER); 
			requirements.push_back(BARRACKS};
			requirements.push_back(FACTORY);
			requirements.push_back(ARMORY);
			break;

		// buildings
		CMD_CENTER:
			name.assign("Command CENTER");
			cost = 400;
			bld_time = 100;
			size = 0;
			supply = 10;
			building = true;
			products.push_back(SCV);
			requirements.erase();
			break;
		SUPPLY_DEPOT:
			name.assign("Supply Depot");
			cost = 100;
			bld_time = 40;
			size = 0;
			supply = 9;
			building = true;
			products = {0};
			requirements.push_back(CMD_CENTER);
			break;
		BARRACKS:
			name.assign("Barracks");
			cost = 100;
			bld_time = 55;
			size = 0;
			supply = 0;
			building = true;
			products.erase();
			requirements.push_back(CMD_CENTER);
			break;
		ACADEMY:
			name.assign("Academy");
			cost = 100;
			bld_time = 40;
			size = 0;
			supply = 0;
			building = true;
			products.erase();
			requirements.push_back(CMD_CENTER);
			requirements.push_back(BARRCKS);
			break;
		FACTORY:
			name.assign("Supply Depot");
			cost = 150;
			bld_time = 60;
			size = 0;
			supply = 0;
			building = true;
			products.erase();
			requirements.push_back(CMD_CENTER);
			requirements.push_back(BARRCKS);
			break;
		MACHINE_SHOP:
			name.assign("Supply Depot");
			cost = 75;
			bld_time = 45;
			size = 0;
			supply = 0;
			building = true;
			products.erase();
			requirements.push_back(CMD_CENTER);
			requirements.push_back(BARRCKS);
			requirements.push_back(FACTORY);
			break;
		ARMORY:
			name.assign("Armory");
			cost = 125;
			bld_time = 50;
			size = 0;
			supply = 0;
			building = true;
			products.erase();
			requirements.push_back(CMD_CENTER);
			requirements.push_back(BARRCKS);
			requirements.push_back(FACTORY);
			break;
		default:
			cout << "ERROR: UNKNOWN UNIT TYPE: " << type<< ". EXITING...\n";
			std::exit(0);
	}
};

unit_param::~unit_param() {
	// nothing to destroy ;(
};

std::sting unit_param::get_name() {
	return name;
};

unsigned int unit_param::get_cost() {
	return cost;
};

unsigned int unit_param::get_bld_time() {
	return bld_time;
};

unsigned int unit_param::get_size() {
	return size;
};

unsigned int unit_param::get_supply() {
	return supply;
};

bool unit_param::is_building() {
	return building;
};

std::list<unit> unit_param::get_products() {
	return products;
};

std::list<unit> unit_param::get_requirements() {
	return reuirements;
};

vector <unit_param> g_unit_param_list;

// CALL IT BEFORE FIRST SIMULATION STARTS
void init_unit_params() {
	for (int i = 0; i < UNIT_TYPE_SIZE; i++) {
		g_unit_param_list.push_back(unit_param(i));
	}
}

unit::unit(unit_type type, bool start_unit) {
	if (start_unit) {
		state = READY;
	} else {
		state = NOT_EXISTS;
	}

	if ( ! (type > NO_UNIT && type < UNIT_TYPE_SIZE) ) {
		parameters = g_unit_param_list[type];
	} else {
		cout << "ERROR: unit class constructor: unknown unit type " << type << "\n";
		std::exit(0);
	}
}

unit_param * unit::get_params(); {
	return parameters;
}

void unit::refresh_state() {
	if (state == UNDER_CONSTRUCTION) {
		if (bld_time_left == 0) {
			state = READY;
		} else {
			bld_time_left --;
		}
	}
}

void unit::start_bld() {
	if (state == NOT_EXISTS) {
		// chceck if unit can be constructed
		state = UNDER_CONSTRUCTION;
		bld_time_left = this.get_params()->get_bld_time();
	} else {
		cout << "ERROR: Cannot start unit " << this.get_params()->get_name() << " build - invalid state = " << state << "\n";
	}
}
