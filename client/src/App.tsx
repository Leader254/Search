import "./App.css";
import {
  AutoComplete,
  AutoCompleteCompleteEvent,
} from "primereact/autocomplete";
import { useState, useEffect } from "react";
import { Button } from "primereact/button";
import { Skeleton } from "primereact/skeleton";

function App() {
  const [value, setValue] = useState("");
  const [items, setItems] = useState<string[]>([]);
  const [isClicked, setIsClicked] = useState<boolean>(false);

  const search = (e: AutoCompleteCompleteEvent) => {
    setItems([...Array(10).keys()].map((item) => e.query + "-" + item));
  };

  const handleSearch = () => {
    console.log("Clicked");
    setIsClicked(!isClicked);
  };
  return (
    <>
      <h3>Search Part By Serial Number....</h3>
      <div className="card flex justify-content-center">
        <AutoComplete
          value={value}
          suggestions={items}
          completeMethod={search}
          onChange={(e) => setValue(e.value)}
          tooltip="Enter a serial Number"
          tooltipOptions={{ position: "left" }}
        />
        <Button
          className="ml-2"
          label="Submit"
          icon="pi pi-check"
          iconPos="right"
          rounded
          onClick={handleSearch}
        />
      </div>
      {isClicked && (
        <div className="border-round border-1 surface-border p-4 surface-card">
          <div className="flex mb-3">
            <Skeleton shape="circle" size="4rem" className="mr-2"></Skeleton>
            <div>
              <Skeleton width="10rem" className="mb-2"></Skeleton>
              <Skeleton width="5rem" className="mb-2"></Skeleton>
              <Skeleton height=".5rem"></Skeleton>
            </div>
          </div>
          <Skeleton width="100%" height="150px"></Skeleton>
          <div className="flex justify-content-between mt-3">
            <Skeleton width="4rem" height="2rem"></Skeleton>
            <Skeleton width="4rem" height="2rem"></Skeleton>
          </div>
        </div>
      )}
    </>
  );
}

export default App;
