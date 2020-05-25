import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGroupTypeComponent } from './create-group-type.component';

describe('CreateGroupTypeComponent', () => {
  let component: CreateGroupTypeComponent;
  let fixture: ComponentFixture<CreateGroupTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateGroupTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateGroupTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
