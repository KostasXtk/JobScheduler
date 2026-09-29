CREATE TABLE jobs (
                      id            uuid PRIMARY KEY DEFAULT gen_random_uuid(),
                      type          text        NOT NULL,
                      payload       jsonb       NOT NULL DEFAULT '{}',
                      status        text        NOT NULL DEFAULT 'pending'
                          CHECK (status IN ('pending', 'running', 'succeeded', 'dead')),
                      run_at        timestamptz NOT NULL DEFAULT now(),
                      attempts      int         NOT NULL DEFAULT 0,
                      max_attempts  int         NOT NULL DEFAULT 5,
                      locked_until  timestamptz,
                      locked_by     text,
                      last_error    text,
                      cron          text,
                      created_at    timestamptz NOT NULL DEFAULT now(),
                      updated_at    timestamptz NOT NULL DEFAULT now()
);

CREATE INDEX idx_jobs_due ON jobs (run_at) WHERE status = 'pending';
CREATE INDEX idx_jobs_expired_lease ON jobs (locked_until) WHERE status = 'running';