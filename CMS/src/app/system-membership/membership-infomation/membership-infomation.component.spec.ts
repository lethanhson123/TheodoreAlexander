import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipInfomationComponent } from './membership-infomation.component';

describe('MembershipInfomationComponent', () => {
  let component: MembershipInfomationComponent;
  let fixture: ComponentFixture<MembershipInfomationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipInfomationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MembershipInfomationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
