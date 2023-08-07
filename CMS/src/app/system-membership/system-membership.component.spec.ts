import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemMembershipComponent } from './system-membership.component';

describe('SystemMembershipComponent', () => {
  let component: SystemMembershipComponent;
  let fixture: ComponentFixture<SystemMembershipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SystemMembershipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SystemMembershipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
