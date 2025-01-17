export interface ICreateTankDto {
    deposito: string;
    capacity: number;
    productType: string;
  }

  export class CreateTankDto implements ICreateTankDto {
    deposito: string;
    capacity: number;
    productType: string;

    constructor(data?: ICreateTankDto) {
      if (data) {
        this.deposito = data.deposito;
        this.capacity = data.capacity;
        this.productType = data.productType;
      }
    }

    static fromJS(data: any): CreateTankDto {
      data = typeof data === "object" ? data : {};
      return new CreateTankDto({
        deposito: data["deposito"],
        capacity: data["capacity"],
        productType: data["productType"]
      });
    }

    toJSON(): any {
      return {
        id: this.deposito,
        capacity: this.capacity,
        productType: this.productType
      };
    }
  }
