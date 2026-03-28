CREATE DATABASE B2B_IdentityDB;     -- Handles both Auth Service & User Service
CREATE DATABASE B2B_CatalogDB;      -- Handles Product Service (The Catalog)
CREATE DATABASE B2B_InventoryDB;    -- Handles Warehouse Stock
CREATE DATABASE B2B_OrderDB;        -- Handles the core Order State Machine
CREATE DATABASE B2B_DeliveryDB;     -- Handles Drivers & Live Tracking
CREATE DATABASE B2B_NotificationDB; -- Handles Email/SMS templates