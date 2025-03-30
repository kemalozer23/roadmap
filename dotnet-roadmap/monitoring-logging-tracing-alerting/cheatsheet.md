# Monitoring/Logging/Tracing/Alerting Cheatsheet (in .NET)

## Monitoring

### On-Premises
- **Prometheus/Grafana**
  - **Prometheus**
    - Metric collection and storage.
    - Pull-based model for collecting metrics from endpoints.
    - Supports custom metrics via client libraries.
    - **Basic Usage**:
      1. Install Prometheus and configure `prometheus.yml`.
      2. Add metrics endpoints to scrape in the configuration file.
      3. Start the Prometheus server and access metrics at `http://localhost:9090`.
  - **Grafana**
    - Visualization tool for Prometheus metrics.
    - Supports alerts, dashboards, and multiple data sources.
    - **Basic Usage**:
      1. Install Grafana and connect it to Prometheus as a data source.
      2. Create custom dashboards and panels to visualize metrics.
      3. Set up alerts for critical thresholds.

### Cloud
- **Datadog**
  - **Key Features**
    - Unified monitoring for metrics, logs, and traces.
    - Pre-built integrations with popular cloud platforms and services.
  - **Benefits**
    - Real-time monitoring of infrastructure and applications.
    - Custom dashboards and alerting capabilities.
  - **Basic Usage**:
    1. Install the Datadog agent on your host.
    2. Configure the agent with API keys and monitored services.
    3. Use the Datadog dashboard to monitor metrics and set up alerts.

---

## Logging

### On-Premises
- **ELK Stack**
  - **Elasticsearch**
    - Full-text search and analytics engine.
    - Provides scalability and high availability for log data.
    - **Basic Usage**:
      1. Install Elasticsearch and configure the `elasticsearch.yml` file.
      2. Start the service and index your logs via REST APIs.
  - **Logstash**
    - Data pipeline tool for ingesting, transforming, and forwarding logs.
    - Supports plugins for input, filter, and output stages.
    - **Basic Usage**:
      1. Define pipelines in the `logstash.conf` file.
      2. Start Logstash and direct logs to Elasticsearch.
  - **Kibana**
    - Data visualization tool for Elasticsearch.
    - Create visualizations, dashboards, and reports from log data.
    - **Basic Usage**:
      1. Connect Kibana to Elasticsearch.
      2. Create custom visualizations and dashboards in the Kibana UI.
- **Seq**
  - Centralized logging platform optimized for structured logs.
  - Provides real-time searching, filtering, and analytics.
  - Simplifies debugging and troubleshooting in .NET applications.
  - **Basic Usage**:
    1. Install Seq and configure your .NET application to send logs to it.
    2. Use the Seq UI to filter and search for specific log events.

### Cloud
- **Datadog**
  - **Key Features**
    - Centralized log collection and live tailing.
    - Advanced search and analytics for log data.
  - **Benefits**
    - Seamless integration with monitoring and tracing for context-aware debugging.
    - Alerting based on log patterns and anomalies.
  - **Basic Usage**:
    1. Configure the Datadog agent to collect application logs.
    2. View and search logs in the Datadog platform.
    3. Set up patterns or alerts for log anomalies.

---

## Tracing

### On-Premises
- **OpenTelemetry → Jaeger**
  - **OpenTelemetry**
    - Open-source framework for collecting telemetry data (traces, metrics, and logs).
    - Supports instrumentation libraries for .NET and other languages.
    - **Basic Usage**:
      1. Add OpenTelemetry SDK to your .NET application.
      2. Configure exporters to send trace data to Jaeger.
  - **Jaeger**
    - Open-source tool for distributed tracing.
    - Helps identify bottlenecks and latency issues in microservices.
    - Provides trace visualization, root cause analysis, and latency monitoring.
    - **Basic Usage**:
      1. Install and run the Jaeger backend services.
      2. Visualize trace data sent by OpenTelemetry in the Jaeger UI.

### Cloud
- **Datadog**
  - **Key Features**
    - Distributed tracing with automatic instrumentation for .NET.
    - Application Performance Monitoring (APM) to analyze service dependencies.
  - **Benefits**
    - End-to-end visibility into application requests.
    - Insights into service performance and error tracking.
  - **Basic Usage**:
    1. Install the Datadog APM libraries in your .NET application.
    2. Configure the application to send trace data to Datadog.
    3. Use the Datadog Traces dashboard to analyze service performance.

---

## Alerting

### On-Premises
- **Zabbix**
  - **Key Features**
    - Open-source monitoring tool for networks, servers, and applications.
    - Rule-based alerting with support for email, SMS, and other notifications.
  - **Benefits**
    - Customizable dashboards and templates.
    - Scalable solution for monitoring large environments.
  - **Basic Usage**:
    1. Install and configure the Zabbix server and agents.
    2. Define monitoring rules and alerting conditions.
    3. Set up notification channels for alerts.

### Cloud
- **Datadog**
  - **Key Features**
    - Proactive alerting with AI-driven anomaly detection.
    - Support for multi-channel notifications (email, Slack, PagerDuty, etc.).
  - **Benefits**
    - Configurable thresholds for custom metrics.
    - Integration with other Datadog services for holistic alerting.
  - **Basic Usage**:
    1. Create alert conditions in the Datadog Alerts section.
    2. Set notification channels for alerts.
    3. Monitor triggered alerts in the dashboard or via notifications.
