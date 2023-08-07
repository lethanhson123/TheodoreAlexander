import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserEmailByDateComponent } from './user-email-by-date.component';

describe('UserEmailByDateComponent', () => {
  let component: UserEmailByDateComponent;
  let fixture: ComponentFixture<UserEmailByDateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserEmailByDateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserEmailByDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
