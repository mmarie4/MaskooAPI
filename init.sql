CREATE TABLE diaries (
    uuid id,
    uuid diary_id,
    timestamp created_at,
    uuid created_by,
    timestamp updated_at,
    uuid updated_by
);

CREATE TABLE days (
    uuid id,
    timestamp date,
    varchar content,
    uuid diary_id,
    timestamp created_at,
    uuid created_by,
    timestamp updated_at,
    uuid updated_by
);

CREATE TABLE users (
    uuid id,
    varchar first_name,
    varchar last_name,
    varchar email,
    varchar password_hash,
    varchar password_salt,
    timestamp created_at,
    uuid created_by,
    timestamp updated_at,
    uuid updated_by
);