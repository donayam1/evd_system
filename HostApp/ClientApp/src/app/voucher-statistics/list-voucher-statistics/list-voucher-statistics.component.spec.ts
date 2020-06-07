import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListVoucherStatisticsComponent } from './list-voucher-statistics.component';

describe('ListVoucherStatisticsComponent', () => {
  let component: ListVoucherStatisticsComponent;
  let fixture: ComponentFixture<ListVoucherStatisticsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListVoucherStatisticsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListVoucherStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
