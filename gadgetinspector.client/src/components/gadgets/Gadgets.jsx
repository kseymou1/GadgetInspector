import { useState, useMemo, useCallback } from "react";
import GadgetsGrid from "./gadgets-grid/GadgetsGrid";
import PageTitleBar from "../layout/page-title-bar/PageTitleBar";
import GridFilters from "./grid-filters/GridFilters";

export default function Gadgets() {
    const [filterValues, setFilterValues] = useState({
        gadgetTypeId: null,
        quickFilterText: null,
    });

    const handleFilterValuesChange = useCallback(newVal => {
        setFilterValues(newVal);
    }, []);

    const gridParams = useMemo(() => {
        return {
            gadgetTypeId: filterValues.gadgetTypeId,
        };
    }, [filterValues.gadgetTypeId]);

    return (
        <>
            <PageTitleBar pageTitle="Gadgets" /> {/* should be in Layout, but we are saving time here */}

            <GridFilters
                onChange={handleFilterValuesChange}
                filterValues={filterValues}
            />

            <GadgetsGrid customParams={gridParams} quickFilterText={filterValues.quickFilterText} />
        </>
    );
}
