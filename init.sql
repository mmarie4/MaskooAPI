CREATE TABLE diaries (
    id uuid,
    user_id uuid,
    created_at timestamp,
    created_by uuid,
    updated_at timestamp,
    updated_by uuid
);

CREATE TABLE days (
    id uuid,
    date timestamp,
    content varchar,
    diary_id uuid,
    created_at timestamp,
    created_by uuid,
    updated_at timestamp,
    updated_by uuid
);

CREATE TABLE users (
    id uuid,
    first_name varchar,
    last_name varchar,
    email varchar,
    password_hash varchar,
    password_salt varchar,
    created_at timestamp,
    created_by uuid,
    updated_at timestamp,
    updated_by uuid
);

CREATE TABLE toolboxes (
    id uuid,
    user_id uuid,
    label varchar,
    created_at timestamp,
    created_by uuid,
    updated_at timestamp,
    updated_by uuid
);

CREATE TABLE tools (
    id uuid,
    toolbox_id uuid,
    label varchar,
    value varchar,
    created_at timestamp,
    created_by uuid,
    updated_at timestamp,
    updated_by uuid
);

CREATE TABLE notes (
    id uuid,
    user_id uuid,
    title varchar,
    content varchar,
    created_at timestamp,
    created_by uuid,
    updated_at timestamp,
    updated_by uuid
);