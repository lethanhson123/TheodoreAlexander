import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemInitializationComponent } from './item-initialization.component';

describe('ItemInitializationComponent', () => {
  let component: ItemInitializationComponent;
  let fixture: ComponentFixture<ItemInitializationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemInitializationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemInitializationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
