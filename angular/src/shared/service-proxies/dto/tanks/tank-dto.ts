export interface ITankDto {
    deposit: string;
    capacity: number;
    productType: string;
    IsDeleted: boolean;
}

export class TankDto implements ITankDto {
    deposit: string;
    capacity: number;
    productType: string;
    IsDeleted: boolean;

    constructor(data?: ITankDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property)) {
                    (<any>this)[property] = (<any>data)[property];
                }
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.deposit = data["deposit"];
            this.capacity = data["capacity"];
            this.productType = data["productType"];
            this.IsDeleted = data["IsDeleted"];
        }
    }

    static fromJS(data: any): TankDto {
        data = typeof data === "object" ? data : {};
        let result = new TankDto();
        result.init(data);

        return result;
    }

    toJSON(data?: any) {
        data = typeof data === "object" ? data : {};
        data["deposit"] = this.deposit;
        data["capacity"] = this.capacity;
        data["productType"] = this.productType;
        data["IsDeleted"] = this.IsDeleted;

        return data;
    }
}
