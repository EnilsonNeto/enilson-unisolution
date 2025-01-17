import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTankComponent } from './edit-tank.component';

describe('EditTankComponent', () => {
  let component: EditTankComponent;
  let fixture: ComponentFixture<EditTankComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTankComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditTankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
