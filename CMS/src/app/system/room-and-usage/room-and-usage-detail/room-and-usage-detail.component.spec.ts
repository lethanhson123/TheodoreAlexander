import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomAndUsageDetailComponent } from './room-and-usage-detail.component';

describe('RoomAndUsageDetailComponent', () => {
  let component: RoomAndUsageDetailComponent;
  let fixture: ComponentFixture<RoomAndUsageDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomAndUsageDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomAndUsageDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
