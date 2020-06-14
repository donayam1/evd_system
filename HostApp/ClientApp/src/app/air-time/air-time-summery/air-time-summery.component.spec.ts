import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AirTimeSummeryComponent } from './air-time-summery.component';

describe('AirTimeSummeryComponent', () => {
  let component: AirTimeSummeryComponent;
  let fixture: ComponentFixture<AirTimeSummeryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AirTimeSummeryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AirTimeSummeryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
