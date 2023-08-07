import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserByStoreComponent } from './user-by-store.component';

describe('UserByStoreComponent', () => {
  let component: UserByStoreComponent;
  let fixture: ComponentFixture<UserByStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserByStoreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserByStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
