import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditGroupTypeComponent } from './edit-group-type.component';

describe('EditGroupTypeComponent', () => {
  let component: EditGroupTypeComponent;
  let fixture: ComponentFixture<EditGroupTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditGroupTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditGroupTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
