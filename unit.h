#include <string>
#include <list>
#include <vector>

// unit type IDs
typedef enum {
	NO_UNIT = 0,

	// ground units
	SCV = 1,
	MARINE,
	FIREBAT,
	GHOST,
	VULTURE,
	TANK,
	GOLIATH,

	// buildings
	CMD_CENTER,
	SUPPLY_DEPOT,
	BARRACKS,
	ACADEMY,
	FACTORY,
	MACHINE_SHOP,
	ARMORY,

	UNIT_TYPE_SIZE
} unit_type;


// below classes are used for simultion purposes only

class unit_param {
	public:
		unit_param(unit_type);
		~unit_param();
		std::sting get_name();
		unsigned int get_cost();
		unsigned int get_bld_time();
		unsigned int get_size();
		unsigned int get_supply();
		bool is_building();
		std::vector<unit> get_products();
		std::vector<unit> get_requirements();

	private:
		std::sting name;
		unsigned int cost;
		unsigned int bld_time;
		unsigned int size;
		unsigned int supply;
		bool building;
		std::vector<unit> products;
		std::vector<unit> requirements;
};

typedef enum {
	NOT_EXISTS = 0,
	UNDER_CONSTRUCTION,
	READY
} unit_state;

class unit {
	public:
		unit(unit_type type, bool start_unit = false);
		~unit();
		unit_param * get_params();
		void refresh_state();	
		void start_bld();

	private:
		unit_param * parameters;
		unit_state state;
		unsigned int bld_time_left;
};

// CALL IT BEFORE FIRST SIMULATION STARTS
void init_unit_params();

export list <unit_param> g_unit_param_list;


