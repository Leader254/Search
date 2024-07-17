import "./App.css";
import { useEffect, useState } from "react";
import { AutoComplete } from "primereact/autocomplete";
import { Button } from "primereact/button";
import { Part } from "./constants/types";

function App() {
  const [serialNumber, setSerialNumber] = useState("");
  const [parts, setParts] = useState<Part[]>([]);
  const [isClicked, setIsClicked] = useState<boolean>(false);

  useEffect(() => {
    const fetchParts = async () => {
      const response = await fetch(
        `https://localhost:7272/api/Parts/${serialNumber}`
      );
      const newData = await response.json();
      console.log("Data is", newData);
      setParts(newData);
    };

    if (isClicked) {
      fetchParts();
    }
  }, [serialNumber, isClicked]);

  const handleSearch = () => {
    setIsClicked(!isClicked);
  };

  return (
    <>
      <h3>Search Part By Serial Number....</h3>
      <div className="card flex justify-content-center">
        <AutoComplete
          value={serialNumber}
          onChange={(e) => setSerialNumber(e.value)}
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
      {parts && (
        <div className="p-grid p-justify-center">
          {parts.map((part) => (
            <div key={part.id} className="p-col-12 p-md-6 p-lg-4 p-mb-3">
              <div className="card p-card">
                <div className="p-card-body">
                  <div>
                    <strong>Name:</strong> {part.name}
                  </div>
                  <div>
                    <strong>Part Number:</strong> {part.partNum}
                  </div>
                  <div>
                    <strong>Company:</strong> {part.company}
                  </div>
                  <div>
                    <strong>Description:</strong> {part.partDescription}
                  </div>
                  <div>
                    <strong>Serial Number:</strong> {part.serialNumber}
                  </div>
                  <div>
                    <strong>Status:</strong> {part.sNStatus}
                  </div>
                  <div>
                    <strong>Customer ID:</strong> {part.custID}
                  </div>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}
    </>
  );
}

export default App;
