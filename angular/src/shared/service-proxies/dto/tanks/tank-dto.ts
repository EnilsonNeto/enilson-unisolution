export interface ITankDto {
    deposito: string;
    capacity: number;
    productType: string;
}

export class TankDto implements ITankDto {
    deposito: string;
    capacity: number;
    productType: string;

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
            this.deposito = data["deposito"];
            this.capacity = data["capacity"];
            this.productType = data["productType"];
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
        data["deposito"] = this.deposito;
        data["capacity"] = this.capacity;
        data["productType"] = this.productType;

        return data;
    }
}
