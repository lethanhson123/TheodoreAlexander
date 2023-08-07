export class HR_Covid {
    ID!: number;
    UserCreated?: string;
    DateCreated?: Date;
    UserUpdated?: string;
    DateUpdated?: Date;
    Active?: boolean;
    RowVersion?: number;
    ParentID?: number;
    CodeManage?: string;
    Note?: string;
    EmployeeID?: number;
    EmployeeCode?: string;
    CovidTypeID?: number;
    CovidLocalID?: number;
    CovidTestID?: number;
    CovidResultID?: number;
    CovidTestDate?: Date;   
    AddressContact?: string;
    AddressContactProvince?: string;
    AddressContactDistrict?: string;
    AddressContactWard?: string;
    IsInjectedVaccine?: boolean;
    IsMaternityLeave?: boolean;
    IsolationRoom?: string;
    IsolationFloot?: string;
    IsolationArea?: string;
    IsolationName?: string;
    IsolationAddress?: string;    
    IsolationDateBegin?: Date;
    IsolationDateEnd?: Date;
    IsolationProvinceID!: number;
    IsolationDistrictID!: number;
    IsolationWardID?: number;
    Symptom?: string;    
}

