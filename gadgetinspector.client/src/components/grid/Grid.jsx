import { AgGridReact } from "ag-grid-react";
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { useRef } from "react";
import "./styles/grid.min.css";

//Thin wrapper around AgGridReact, based on this: https://www.ag-grid.com/react-data-grid/getting-started/
export default function Grid(props) {
    const { gridOptions, className = "" } = props;

    const gridRef = useRef();

    const defaultGridOptions = {
        reactiveCustomComponents: true,
        pagination: true,
        paginationPageSize: 10,
        paginationPageSizeSelector: [10, 25, 100],
        animateRows: false, //KS: These are cutesy, but I find they give the appearance of worse performance
        //getRowStyle: params => {
        //    // KS:
        //    // By design, AG shows a row with no data while fetching: https://github.com/ag-grid/ag-grid/issues/1665
        //    // It's an option to do something with this row to indicate loading. But we've currently opted to use the AG loadingOverlay instead
        //    // "getRowStyle" can also be used to dynamically style rows based on the data inside.  However this is probably worse than
        //    // using a row template or component.  So I expect to never use "getRowStyle" in this way.
        //    // At the very least, you may want to consider using "getRowClass" before using "getRowStyle"
        //    if (params.data === undefined) return { display: 'none' }
        //},
    };

    const finalGridOptions = { ...defaultGridOptions, ...gridOptions };

    const finalClassName = `grid-container ${className ?? ""}`.trim();

    return (
        <div className={finalClassName}>
            <div className="ag-theme-quartz">
                <AgGridReact
                    ref={gridRef}
                    {...finalGridOptions}
                />
            </div>
        </div>
    );
}