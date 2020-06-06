import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListvoucherBatchComponent } from './listvoucher-batch.component';

describe('ListvoucherBatchComponent', () => {
  let component: ListvoucherBatchComponent;
  let fixture: ComponentFixture<ListvoucherBatchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListvoucherBatchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListvoucherBatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
