import { useState, useEffect, useMemo, useCallback } from "react";
import Grid from "../../grid/Grid";
import apiRoutes from "../../../support/routes/apiRoutes";
import axios from "axios";
import getDateStringFromJsDate from "../../../util/stringFormatters/getDateStringFromJsDate";
import notify from "../../../support/notify/notify";
import TechnicianCellEditor from "./technician-cell-editor/TechnicianCellEditor";

export default function GadgetsGrid(props) {
    const { customParams, quickFilterText } = props;

    const [rowData, setRowData] = useState([]);
    const [gridApi, setGridApi] = useState(null);

    //Reload grid when customParams are updated:
    useEffect(() => {
        if (!customParams || !gridApi) return;

        gridApi.setGridOption("loading", true);

        axios.post(apiRoutes.gadget.getGridItems(), customParams)
            .then(resp => {
                //We are only worried about the date itself. No time zones. These values are equal for everyone no matter
                //where they are in the world when looking at this screen.
                //For the AG date editors to work, we must pass in a JS date object.
                //So we transform the ISO string into a date
                //First we slice off the "Z", so it doesn't decide to convert 1-1-2025 midnight UTC into 12-31-2024 9PM
                const transformedData = resp.data.map((x) => ({
                    ...x,
                    lastInspectedDate: new Date(x.lastInspectedDate.slice(0, -1)),
                    dueDate: new Date(x.dueDate.slice(0, -1)),
                    scheduledDate: x.scheduledDate ? new Date(x.scheduledDate.slice(0, -1)) : null,
                }));

                setRowData(transformedData);
            })
            .catch(() => {
                notify.error("Error fetching Gadgets grid.");
            })
            .finally(() => {
                gridApi.setGridOption("loading", false);
            });
    }, [customParams, gridApi]);

    const handleScheduledDateChange = useCallback(event => {
        const { oldValue, newValue, column, data, node } = event;

        const postParams = { gadgetId: data.gadgetId, scheduledDate: newValue };

        axios.post(apiRoutes.inspection.addScheduledDateToGadget(), postParams)
            .then(() => {
                notify.success("Scheduled Date saved.");
            })
            .catch(() => {
                notify.error(`Error saving Scheduled Date.`);
                data[column.colId] = oldValue;
                node.setData(data);
            });
    }, []);

    //AG recommends useMemo for grid options
    const columnDefinitions = useMemo(() => [
        {
            flex: 1,
            field: "gadgetTypeName",
            headerName: "Type",
        },
        {
            flex: 1,
            field: "gadgetName",
            headerName: "Gadget",
        },
        {
            flex: 1,
            field: "lastInspectedDate",
            valueFormatter: params => getDateStringFromJsDate(params.value),
            getQuickFilterText: params => getDateStringFromJsDate(params.value),
        },
        {
            flex: 1,
            field: "dueDate",
            valueFormatter: params => getDateStringFromJsDate(params.value),
            getQuickFilterText: params => getDateStringFromJsDate(params.value),
        },
        {
            flex: 1,
            field: "daysRemaining",
            type: "rightAligned",
            sort: "asc",
            cellStyle: params => {
                if (params.value <= 0) {
                    return {
                        color: 'darkred',
                        backgroundColor: 'lightpink',
                        fontWeight: "bold"
                    };
                }
                return null;
            },
        },
        {
            flex: 1,
            field: "scheduledDate",
            valueFormatter: params => getDateStringFromJsDate(params.value),
            getQuickFilterText: params => getDateStringFromJsDate(params.value),
            editable: true,
            cellEditor: 'agDateCellEditor',
            onCellValueChanged: handleScheduledDateChange,
        },
        {
            flex: 1,
            field: "scheduledTechnicianName",
            headerName: "Scheduled Technician",
            editable: true,
            cellEditor: TechnicianCellEditor,
            cellEditorPopup: true,
        },

    ], [handleScheduledDateChange]);

    const gridOptions = useMemo(() => {
        const gridOpts = {};

        gridOpts.defaultColDef = { sortable: true };
        gridOpts.columnDefs = columnDefinitions;
        gridOpts.rowData = rowData;
        gridOpts.quickFilterText = quickFilterText;
        gridOpts.suppressRowHoverHighlight = true;
        gridOpts.singleClickEdit = true; //default is double-click
        gridOpts.popupParent = document.body; //This is to stop the grid from containing the typeahead results and looking weird
        const onGridReady = (params) => {
            //Initialize gridApi
            setGridApi(params.api);
        };
        gridOpts.onGridReady = onGridReady;

        return gridOpts;
    }, [columnDefinitions, rowData, quickFilterText]);

    return (
        <Grid gridOptions={gridOptions} />
    );
}