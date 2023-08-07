import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomAndUsageComponent } from './room-and-usage.component';

describe('RoomAndUsageComponent', () => {
  let component: RoomAndUsageComponent;
  let fixture: ComponentFixture<RoomAndUsageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomAndUsageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomAndUsageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
