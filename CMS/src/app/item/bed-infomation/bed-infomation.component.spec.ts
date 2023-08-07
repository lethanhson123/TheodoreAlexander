import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BedInfomationComponent } from './bed-infomation.component';

describe('BedInfomationComponent', () => {
  let component: BedInfomationComponent;
  let fixture: ComponentFixture<BedInfomationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BedInfomationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BedInfomationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
