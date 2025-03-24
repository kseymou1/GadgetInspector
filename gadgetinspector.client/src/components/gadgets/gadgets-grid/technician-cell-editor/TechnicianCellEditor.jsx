import { useCallback } from "react";
import TechnicianTypeahead from "../../../forms/typeaheads/technician-typeahead/TechnicianTypeahead";
import axios from "axios";
import notify from "../../../../support/notify/notify";
import apiRoutes from "../../../../support/routes/apiRoutes";

export default function TechnicianCellEditor(props) {
    const { data, node, stopEditing, onValueChange } = props;

    const handleSelect = useCallback(async (selectedItem) => {
        const technicianId = (selectedItem.id === null || selectedItem.id === undefined) ? null : selectedItem.id;
        const postParams = { gadgetId: data.gadgetId, technicianId: technicianId };

        axios.post(apiRoutes.inspection.assignTechnicianToGadget(), postParams)
            .then(() => {
                data["scheduledTechnicianName"] = selectedItem.name;
                node.setData(data);
                onValueChange(selectedItem.name); //AG says to call this after a value change in order to update the linked value to this editor

                notify.success(`Technician saved.`);
            })
            .catch(() => {
                notify.error(`Error saving Technician.`);
            })
            .finally(() => {
                stopEditing(); //This is AG's method to close the editor.
            });
    }, [data, node, onValueChange, stopEditing]);

    return (
        <TechnicianTypeahead onSelect={handleSelect} />
    );
}