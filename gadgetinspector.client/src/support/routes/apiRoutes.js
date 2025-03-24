const p = `api/v1/`;

//Route roots
const routeRoots = {
    Inspection: {
        Root: p + "Inspection/",
    },
    Gadget: {
        Root: p + "Gadget/",
    },
    GadgetType: {
        Root: p + "GadgetType/",
    },
    Technician: {
        Root: p + "Technician/",
    },
};

const apiRoutes = {
    inspection: {
        assignTechnicianToGadget: () => routeRoots.Inspection.Root + "AssignTechnicianToGadget",
        addScheduledDateToGadget: () => routeRoots.Inspection.Root + "AddScheduledDateToGadget",
        getForTechnician: (technicianId) => routeRoots.Inspection.Root + `GetForTechnician/${technicianId}`,
        markComplete: () => routeRoots.Inspection.Root + "MarkComplete",
    },
    gadget: {
        getGridItems: () => routeRoots.Gadget.Root + "GetGridItems",
    },
    gadgetType: {
        get: () => routeRoots.GadgetType.Root + "Get",
    },
    technician: {
        getSuggestions: (searchText) => routeRoots.Technician.Root + `GetSuggestions/${searchText}`,
    },
};

export default apiRoutes;