import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService } from 'ngx-bootstrap/modal';
import { PagedListingComponentBase, PagedRequestDto, } from '@shared/paged-listing-component-base';
import { TankDto } from '@shared/service-proxies/dto/tanks/tank-dto';
import { TankServiceProxy } from '@shared/service-proxies/service-proxies';
import { TankDtoPagedResultDto } from '@shared/service-proxies/dto/tanks/tank-dto-paged-result.ts';
import { TankFormComponent } from './tank-form/tank-form.component';

class PagedTanksRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-tanks',
  templateUrl: './tanks.component.html'
})
export class TanksComponent extends PagedListingComponentBase<TankDto> {
  tanks: TankDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _modalService: BsModalService,
    private _tankService: TankServiceProxy
  ) {
    super(injector);
  }

  filterData(): void {
    if (this.keyword.trim() === '') {
      this.getDataPage(1);
    } else {
      this.getDataPage(1);
    }
  }

  list(
    request: PagedTanksRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword.trim().toLowerCase();
    request.isActive = true;
    request.skipCount = (pageNumber - 1) * request.maxResultCount;

    this._tankService
      .getAll(
        request.keyword,
        request.isActive,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: TankDtoPagedResultDto) => {
        this.tanks = result.items.filter(tank =>
          tank.deposit.toLowerCase().includes(request.keyword)
        );
        this.showPaging(result, pageNumber);
      });
  }

  createTank(): void {
    this.showCreateOrEditTankDialog();
  }

  editTank(tank: TankDto): void {
    this.showCreateOrEditTankDialog(tank);
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  delete(tank: TankDto): void {
    abp.message.confirm(
      this.l(`Tem certeza que deseja excluir este ${tank.deposit}`),
      undefined,
      (result: boolean) => {
        if (result) {
          this._tankService
            .delete(tank.deposit)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => { });
        }
      }
    );
  }

  showCreateOrEditTankDialog(tank?: TankDto): void {
    const createOrEditTankDialog = this._modalService.show(
      TankFormComponent,
      {
        class: 'modal-lg',
        initialState: {
          mode: tank ? 'update' : 'create',
          tank: tank || new TankDto(),
        },
      }
    );

    createOrEditTankDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

}
