import { Component, EventEmitter, Injector, Input, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { TankDto } from '@shared/service-proxies/dto/tanks/tank-dto';
import { TankServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-tank-form',
  templateUrl: './tank-form.component.html',
})
export class TankFormComponent extends AppComponentBase implements OnInit {
  @Input() mode: 'create' | 'update';
  @Input() tank: TankDto;
  @Output() onSave = new EventEmitter<void>();

  saving = false;

  constructor(
    injector: Injector,
    private _tankService: TankServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    if (!this.tank) {
      this.tank = new TankDto();
    }
  }

  save(): void {
    this.saving = true;

    if (this.mode === 'create') {
      this._tankService
        .create(this.tank)
        .pipe(finalize(() => (this.saving = false)))
        .subscribe(() => {
          abp.notify.success(this.l('SuccessfullyCreated'));
          this.onSave.emit();
          this.bsModalRef.hide();
        });
    } else {
      this._tankService
        .updateTankAsync(this.tank)
        .pipe(finalize(() => (this.saving = false)))
        .subscribe(() => {
          abp.notify.success(this.l('SuccessfullyUpdated'));
          this.onSave.emit();
          this.bsModalRef.hide();
        });
    }
  }
}