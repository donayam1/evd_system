import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListConfigureBankComponent } from './list-configure-bank.component';

describe('ListConfigureBankComponent', () => {
  let component: ListConfigureBankComponent;
  let fixture: ComponentFixture<ListConfigureBankComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListConfigureBankComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListConfigureBankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
