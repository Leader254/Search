export interface Part {
    id: number;
    name: string;
    partNum: string;
    company: string;
    partDescription: string;
    serialNumber: string;
    sNStatus: SNStatusType;
    custID: string;
  }
  
  type SNStatusType = 'ADJUSTED' | 'CONSUMED' | 'DMR' | 'INSPECTION' | 'INVENTORY'
    | 'MISC-ISSUE' | 'PACKED' | 'REJECTED' | 'RMA-ENTRY' | 'SHIPPED' | 'SUBSHIPPED' | 'WIP';
  