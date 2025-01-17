export interface ICreateTankDto {
    deposit: string;
    capacity: number;
    productType: string;
    IsDeleted: boolean;
  }

  export class CreateTankDto implements ICreateTankDto {
    deposit: string;
    capacity: number;
    productType: string;
    IsDeleted: boolean;

    constructor(data?: ICreateTankDto) {
      if (data) {
        this.deposit = data.deposit;
        this.capacity = data.capacity;
        this.productType = data.productType;
        this.IsDeleted = data.IsDeleted;
      }
    }

    static fromJS(data: any): CreateTankDto {
      data = typeof data === "object" ? data : {};
      return new CreateTankDto({
        deposit: data["deposit"],
        capacity: data["capacity"],
        productType: data["productType"],
        IsDeleted: data["IsDeleted"]
      });
    }

    toJSON(): any {
      return {
        deposit: this.deposit,
        capacity: this.capacity,
        productType: this.productType,
        IsDeleted: this.IsDeleted
      };
    }
  }
